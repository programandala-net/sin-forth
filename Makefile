# Makefile
# by Marcos Cruz (programandala.net), 2020, 2023.
# Last modified: 20230501T1330+0200.

# This file is part of Sin Forth
# by Marcos Cruz (programandala.net), 2010/2023.

# ==============================================================
# License

# You may do whatever you want with this work, so long as you
# retain every copyright, credit and authorship notice, and this
# license.  There is no warranty.

# ==============================================================
# Requirements {{{1

# Asciidoctor (by Dan Allen, Sarah White et al.)
#   http://asciidoctor.org

# Asciidoctor EPUB3 (by Dan Allen and Sarah White)
#   (>v0.5.0.alpha.15)
#   http://github.com/asciidoctor/asciidoctor-epub3

# Asciidoctor PDF (by Dan Allen and Sarah White)
#   http://github.com/asciidoctor/asciidoctor-pdf

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
	rm -f target/test_*

.PHONY: cleandoc
cleandoc: cleanmanual

# ==============================================================
# Tests files {{{1

source_tests=$(wildcard src/test/*.fs)
tests_names=$(notdir $(basename $(source_tests)))
target_tests=$(addprefix target/, $(tests_names))
disassembled_tests=$(addsuffix .asm, $(target_tests))

# ==============================================================
# Compile the tests {{{1

.PHONY: tests
tests:
	@for file in $$(ls src/test/*.fs);do\
		echo "$$file";\
		src/sin_forth.fs -tap -out $$(realpath target) build $$(realpath $$file);\
	done

target/%.tap: src/test/%.fs
	@src/sin_forth.fs -tap -out $$(realpath target) build $$(realpath $<)

# ==============================================================
# Disassemble the compiled tests {{{1

.PHONY: asm
asm: $(disassembled_tests)

target/%.asm: src/test/%.fs
	@src/sin_forth.fs \
		-addr \
		-code \
		-sym \
		-z80dasm \
		-out $$(realpath target) \
		build $$(realpath $<);\
	z80dasm \
		--address \
		--labels \
		--source \
		--origin=$$(cat $(basename $@).origin.txt) \
		--sym-input=$(basename $@).symbols.asm \
		--block-def=$(basename $@).z80dasm_blocks.txt \
		--output=$@ \
		$(basename $@).bin 2> /dev/null

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
