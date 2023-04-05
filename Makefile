# Makefile

# This file is part of:

# Sin Forth

# A Forth cross-compiler, written in Forth with Gforth,
# that compiles Forth programs for the Sinclair ZX Spectrum.

# By Marcos Cruz (programandala.net), 2020, 2023.

# Last modified: 20230405T1816+0200.
# See change log at the end of the file.

# ==============================================================
# Requirements {{{1

# Asciidoctor (by Dan Allen, Sarah White et al.)
#   http://asciidoctor.org

# Asciidoctor EPUB3 (by Dan Allen and Sarah White)
#   (>v0.5.0.alpha.15)
#   http://github.com/asciidoctor/asciidoctor-epub3

# Asciidoctor PDF (by Dan Allen and Sarah White)
#   http://github.com/asciidoctor/asciidoctor-pdf

# bin2code (by Metalbrain)
#   http://metalbrain.speccy.org/link-eng.htm

# bin2tap (by Metalbrain)
#   http://metalbrain.speccy.org/link-eng.htm

# cat (by Torbjorn Granlund and Richard M. Stallman)
#   Part of GNU Coreutils
#   http://gnu.org/software/coreutils

# Glosara (by Marcos Cruz)
#   http://programandala.net/en.program.glosara.html

# sort (by Mike Haertel and Paul Eggert)
#   Part of GNU Coreutils
#   http://gnu.org/software/coreutils

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

.PHONY: doc
doc: manual

.PHONY: distclean
distclean: clean cleandoc

.PHONY: clean
clean:
	rm -f target/*

.PHONY: cleandoc
cleandoc: cleanmanual

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

# XXX OLD method
.PHONY: tests_old
tests_old:
	cp -f src/test/*.fs target/;\
	cd target/;\
	run-parts --regex='.*\.fs' .;\
	rm -f *.fs

# XXX NEW method
.PHONY: tests
tests: bins taps asms

.PHONY: bins
bins: $(compiled_tests)

target/%.bin: src/test/%.fs
	./$<;\
	mv -f test_* target/

target/%.bas: src/test/%.fs
	./$<;\
	mv -f test_* target/

# ==============================================================
# Disassembly the compiled tests {{{1

# ----------------------------------------------
# Disassembly all executables {{{2

# XXX OLD method
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

# XXX NEW method
.PHONY: asms
asms: $(disassembled_tests)

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

# XXX OLD
.PHONY: bin2tap
bin2tap:
	@for file in $$(ls target/*.bin);do\
		bin2tap $$file $$file.tap;\
	done;

# ----------------------------------------------
# Convert a BAS and a BIN into a TAP {{{2

.PHONY: taps
taps: $(taped_tests)

%.bas.tap: %.bas
	zmakebas -n Autoload -a 1 -o $@ $<

%.bin.tap: %.bin
	bin2code $< $@

%.tap: %.bas.tap %.bin.tap
	cat $^ > $@

# ==============================================================
# Documentation {{{1

# ----------------------------------------------
# Variables {{{2

version=$(shell cat VERSION.txt)

book=sin_forth
title="Sin Forth"
lang="en"
editor="Marcos Cruz"
publisher="programandala.net"
description="Sin Forth user manual"

cover=$(book)_cover
cover_author="Marcos Cruz\n(programandala.net)"
cover_title="Sin Forth"
cover_subtitle="Version $(version)"

core_files = $(sort $(wildcard src/*.fs))
lib_files = $(sort $(wildcard src/lib/*.fs))

# ----------------------------------------------
# Common rules {{{2

%.zip: %
	zip -9 $@ $<

%.gz: %
	gzip -9 --force --keep $<

%.html: %.adoc
	asciidoctor --out-file=$@ $<

%.glossary.adoc: %.files.txt
	glosara --level=4 --sections --input=$< > $@

tmp/doc.%.linked.adoc: src/doc/%.adoc
	glosara --annex $< > $@

tmp/doc.README.linked.adoc: README.adoc
	glosara --annex $< > $@

%.dbk: %.adoc
	asciidoctor \
		--backend=docbook \
		--attribute=version=$(version) \
		--out-file=$@ $<

# ----------------------------------------------
# User manual {{{2

.PHONY: manual
manual: epub html pdf

.PHONY: cleanmanual
cleanmanual:
	rm -f doc/* tmp/doc.*

.PHONY: epub
epub: \
	doc/sin_forth_manual.epub

.PHONY: html
html: \
	doc/sin_forth_manual.html

.PHONY: pdf
pdf: \
	doc/sin_forth_manual.pdf

doc/sin_forth_manual.epub: \
	tmp/doc.manual.adoc \
	README.adoc \
	doc/$(cover).jpg
	asciidoctor-epub3 \
		--trace \
		--attribute=epub-chapter-level=2 \
		--attribute=version=$(version) \
		--out-file=$@ $< \
		2> tmp/doc.unknown_anchors.log

doc/sin_forth_manual.pdf: \
	tmp/doc.manual.adoc \
	README.adoc \
	tmp/$(cover).pdf
	asciidoctor-pdf \
		--trace \
		--attribute=version=$(version) \
		--out-file=$@ $<

doc/sin_forth_manual.html: \
	tmp/doc.manual.adoc \
	README.adoc
	asciidoctor \
		--attribute=version=$(version) \
		--out-file=$@ $<

tmp/doc.files.txt: \
	$(core_files) \
	$(lib_files)
	ls -1 $^ > $@

# Preserve the links in the DocBook source by removing the
# enclosing <literal> tags:

doc/sin_forth_manual.dbk: tmp/doc.manual.dbk
	sed \
		-e "s/<literal><link/<link/g" \
		-e "s/<\/link><\/literal>/<\/link>/g" $< > $@

tmp/doc.manual.adoc: \
	tmp/doc.manual_skeleton.linked.adoc \
	tmp/doc.stack_notation.linked.adoc \
	tmp/doc.z80_flags_notation.linked.adoc \
	tmp/doc.z80_instructions.linked.adoc \
	src/doc/glossary_heading.adoc \
	tmp/doc.glossary.adoc \
	tmp/doc.README.linked.adoc \
	VERSION.txt
	cat \
		tmp/doc.manual_skeleton.linked.adoc \
		tmp/doc.stack_notation.linked.adoc \
		tmp/doc.z80_flags_notation.linked.adoc \
		tmp/doc.z80_instructions.linked.adoc \
		src/doc/glossary_heading.adoc \
		tmp/doc.glossary.adoc \
		> $@

# ----------------------------------------------
# Cover image {{{2

include Makefile.cover_image

# ==============================================================
# Change log {{{1

# 2020-12-10: Start. Add rules to compile all tests, disassembly them and
# convert the executables into ZX Spectrum TAP files.
#
# 2020-12-11: Prepare the rules to build the documentation, adapted from the
# <Makefile> of Solo Forth.
#
# 2020-12-13: Build an online version of the README file, as part of the
# embedded documentation.
#
# 2020-12-24: Fix the title of the online README.
#
# 2020-12-25: Add a rule to build a TAP file from a test BASIC loader, in order
# to build the final TAP file directly.
#
# 2020-12-26: Improve thP rule names. Improve `tests` to build also TAP and
# assembly files.
#
# 2023-04-05: Remove online documentation rules, after migrating to Mercurial.
