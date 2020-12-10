# Makefile

# This file is part of:

# Sin Forth

# A Forth cross-compiler, written in Forth with Gforth,
# that compiles Forth programs for the Sinclair ZX Spectrum.

# By Marcos Cruz (programandala.net), 2020.

# Last modified: 202012100315.
# See change log at the end of the file.

# ==============================================================
# Requirements {{{1

# bin2code (by Metalbrain)
#   http://metalbrain.speccy.org/link-eng.htm

# z80dasm (by Tomaž Šolc)
#   https://www.tablix.org/~avian/blog/articles/z80dasm/

# ==============================================================
# Rules {{{1

.PHONY: tests
tests:
	@run-parts --regex='.*\.fs' src/test;\
	mv -f test* target/

.PHONY: asm
asm:
	@for file in $$(ls target/*.bin);do\
		base=target/$$(basename $${file} .bin);\
		z80dasm -a -g 40000 -l -t \
			-S $$base.symbols.asm \
			-b $$base.z80dasm_blocks.txt \
			-o $$base.asm \
			$$file;\
	done;

.PHONY: taps
taps:
	@for file in $$(ls target/*.bin);do\
		bin2tap $$file $$file.tap;\
	done;

.PHONY: clean
clean:
	@rm -f target/*

# ==============================================================
# Change log {{{1

# 2020-12-10: Start. Add rules to compile all tests, disassembly them and
# convert the executables into ZX Spectrum TAP files.
