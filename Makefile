# Makefile

# This file is part of:

# Sin Forth

# A Forth cross-compiler, written in Forth with Gforth,
# that compiles Forth programs for the Sinclair ZX Spectrum.

# By Marcos Cruz (programandala.net), 2020.

# Last modified: 202012110011.
# See change log at the end of the file.

# ==============================================================
# Requirements {{{1

# bin2code (by Metalbrain)
#   http://metalbrain.speccy.org/link-eng.htm

# bin2tap (by Metalbrain)
#   http://metalbrain.speccy.org/link-eng.htm

# z80dasm (by Tomaž Šolc)
#   https://www.tablix.org/~avian/blog/articles/z80dasm/

# zmakebas (by Russell Marks)
#   Usually included in Linux distros. Also see:
#   http://sourceforge.net/p/emuscriptoria/code/HEAD/tree/desprot/ZMakeBas.c
#   https://github.com/catseye/zmakebas
#   http://zmakebas.sourcearchive.com/documentation/1.2-1/zmakebas_8c-source.html

# ==============================================================
# Main {{{1

.PHONY: all
all: tests

.PHONY: tests
tests: bin asm tap

.PHONY: clean
clean:
	@rm -f target/*

# ==============================================================
# Tests files {{{1

source_tests=$(wildcard src/test/*.fs)
tests_names=$(notdir $(basename $(source_tests)))
target_tests=$(addprefix target/, $(tests_names))
compiled_tests=$(addsuffix .bin, $(target_tests))
taped_tests=$(addsuffix .tap, $(target_tests))
disassembled_tests=$(addsuffix .asm, $(target_tests))

# ==============================================================
# Compile the tests {{{1

# XXX OLD
.PHONY: tests_old
tests_old:
	cp -f src/test/*.fs target/;\
	cd target/;\
	run-parts --regex='.*\.fs' .;\
	rm -f *.fs

# XXX NEW
.PHONY: bin
bin: $(compiled_tests)

# XXX TODO
# target/%.fs: src/test/%.fs
# 	./$<;\
# 	mv -f test_* target/

target/%.bin: src/test/%.fs
	./$<;\
	mv -f test_* target/

# XXX TODO
# %.bin: %.fs
# 	cp -f src/test/$< $(dir 
# 	./$<

# ==============================================================
# Disassembly the compiled tests {{{1

# ----------------------------------------------
# Disassembly all executables {{{2

# XXX OLD
.PHONY: asm_old
asm_old:
	@for file in $$(ls target/*.bin);do\
		base=target/$$(basename $${file} .bin);\
		z80dasm -a -g 40000 -l -t \
			-S $$base.symbols.asm \
			-b $$base.z80dasm_blocks.txt \
			-o $$base.asm \
			$$file;\
	done;

# XXX NEW
.PHONY: asm
asm: $(disassembled_tests)

# ----------------------------------------------
# Disassembly an executable {{{2

# XXX TODO Get the origin address from the source.

%.asm: %.bin
	z80dasm -a -g 40000 -l -t \
		-S $(basename $<).symbols.asm \
		-b $(basename $<).z80dasm_blocks.txt \
		-o $(basename $<).asm \
		$<

# ==============================================================
# Emulator media {{{1

# ----------------------------------------------
# Convert all BIN into TAP with bin2tap {{{2

# This rule is deprecated. bin2tap creates a TAP from an executable, adding a
# custom BASIC loader first, but the execution address has to be indicated as
# an argument, which is not currently possible. By default, the start address
# of the code is used.

.PHONY: bin2tap
bin2tap:
	@for file in $$(ls target/*.bin);do\
		bin2tap $$file $$file.tap;\
	done;

# ----------------------------------------------
# Convert a BAS and a BIN into a TAP {{{2

.PHONY: tap
tap: $(taped_tests)

%.bas.tap: %.bas
	zmakebas -n Autoload -a 1 -o $@ $<

%.bin.tap: %.bin
	bin2code $< $@

%.tap: %.bas.tap %.bin.tap
	cat $^ > $@

# ==============================================================
# Change log {{{1

# 2020-12-10: Start. Add rules to compile all tests, disassembly them and
# convert the executables into ZX Spectrum TAP files.
