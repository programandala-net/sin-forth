#! /usr/bin/env gforth

\ test_07_stack.fs

\ This file is part of:

\ Sin Forth

\ A Forth cross-compiler, written in Forth with Gforth,
\ that compiles Forth programs for the Sinclair ZX Spectrum.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012151856.
\ See change log at the end of the file.

\ ==============================================================

require sin_forth/compiler.fs

40000 set-origin
s" test_07_stack" set-filename

begin-program

require sin_forth/lib/emit.fs     \ `emit`
require sin_forth/lib/literal.fs  \ `literal`
require sin_forth/lib/drop.fs     \ `drop`
require sin_forth/lib/dup.fs      \ `dup`
require sin_forth/lib/over.fs     \ `over`
require sin_forth/lib/swap.fs     \ `swap`
require sin_forth/lib/two-over.fs \ `2over`

boot-here

65 literal \ "A"
66 literal \ "B"
67 literal \ "C"
68 literal \ "D"

2over swap emit \ "A"
       dup emit \ "B"
      drop
      swap emit \ "C"
           emit \ "D"
13 literal emit \ carriage return
      swap emit \ "A"
           emit \ "B"

67 literal \ "C"
68 literal \ "D"

      over emit \ "C"
           emit \ "D"
      drop

ret,

6 data-stack-here

end-program

\ ==============================================================
\ Change log {{{1

\ 2020-12-24: Start. Test `swap` and `over` and `2over`.
