# Sin Forth

## Description

Sin Forth is a Forth cross compiler under development, written in
[Forth](http://forth-standard.org) with
[Gforth](http://gnu.org/software/gforth).

Sin Forth creates machine code programs for any model of [ZX
Spectrum](https://en.wikipedia.org/wiki/ZX_Spectrum) or compatible
computer, including the [ZX Spectrum Next](https://specnext.com).

Author’s website: <http://programandala.net>.

## Installation

The installation of Sin Forth needs two operations:

1.  Make its sources accessible from Gforth.

2.  Copy or link the compiler file (src/sin_forth.fs) in a directory of
    the system `PATH`.

### Sources

There are two methods to make Sin Forth’s sources accessible from
Gforth:

1.  Add the Sin Forth’s \<src\> directory to Gforth’s `fpath`. Consult
    Gforth’s documentation.

2.  Make a symbolic link to Sin Forth’s \<src\> directory in Gforth’s
    \<site-forth\> directory. In a locally compiled Gforth, the command
    on a Linux shell would be the following:

        sudo ln -s SIN_FORTH_PATH/src/ /usr/local/share/gforth/site-forth/sin_forth

    where "SIN_FORTH_PATH" must be replaced with the corresponding path
    to Sin Forth’s directory on your system.

### Compiler

In order to make \<src/sin_forth.fs\> accessible anywhere, you may link
it to any directory in your system `PATH`, removing its filename
extension for convenience:

Example:

    ln -s SIN_FORTH_PATH/src/sin_forth.fs DIR/sin_forth

where "SIN_FORTH_PATH" must be replaced with the corresponding path to
Sin Forth’s directory on your system, and "DIR" can be replaced with
`~/bin` or `~/.local/bin`.

## Requirements

- Sin Forth uses some modules of the [Galope
  library](http://programandala.net/en.program.galope.html).

- Some modules of Galope need modules of the [Forth Foundation
  Library](http://irdvo.nl/FFL/).

- Sin Forth makes the ZX Spectrum .tap files by Metalbrain’s
  [bin2tap](http://metalbrain.speccy.org/link-eng.htm), which must be
  installed in the system.

## Project directories

<table data-custom-style="horizontal">
<colgroup>
<col style="width: 15%" />
<col style="width: 85%" />
</colgroup>
<tbody>
<tr>
<td><p><code>doc</code></p></td>
<td><p>Manuals in EPUB, HTML and PDF</p></td>
</tr>
<tr>
<td><p><code>src</code></p></td>
<td><p>Compiler sources</p></td>
</tr>
<tr>
<td><p><code>src/doc</code></p></td>
<td><p>Documentation sources</p></td>
</tr>
<tr>
<td><p><code>src/lib</code></p></td>
<td><p>Library sources</p></td>
</tr>
<tr>
<td><p><code>src/test</code></p></td>
<td><p>Tests sources</p></td>
</tr>
<tr>
<td><p><code>target</code></p></td>
<td><p>Compiled and disassembled tests</p></td>
</tr>
<tr>
<td><p><code>tmp</code></p></td>
<td><p>Temporary files created by <code>make</code></p></td>
</tr>
</tbody>
</table>

## The name

Sin Forth is a "sin", because the programs it creates are not *actual*
Forth:

- No dictionary.

- No outer interpreter.

- No inner interpreter: the "compiled" code is a collection of machine
  code subroutines, like in a STC (Subroutine-Threaded Code) Forth.

- No distinction between interpretation and compilation modes in the
  source code of the programs: during the "compilation", parsing and
  "immediate" operations are done by host words, i.e. Gforth words.

Besides, "sin Forth" is the Spanish for "without Forth", which is
another way to describe Sin Forth.

Last, "Sin" is borrowed from "Sinclair".

## History of the repository

- 2018-08-19: A Git repository was created from the development backups
  in order to resume the development.

- 2020-12-06: The Git repository was converted to
  [Fossil](http://fossil-scm.org).

- 2020-12-18: A [GitHub
  mirror](http://github.com/programandala-net/sin-forth) was configured
  in the Fossil repository.

- 2023-04-05: The repository was converted to
  [Mercurial](http://mercurial-scm.org), enabling a better interaction
  with GitHub.

- 2023-10-13: The repository was [published on
  SourceHut](https://hg.sr.ht/~programandala_net/sin_forth); GitHub is
  kept as a mirror.
