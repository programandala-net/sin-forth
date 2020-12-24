#! /usr/bin/env gforth

\ test_07_stack.fs

\ This file is part of Sin Forth.

\ A Forth cross-compiler, written in Forth with Gforth,
\ that compiles Forth programs for the Sinclair ZX Spectrum.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012240244.
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
require sin_forth/lib/two-drop.fs \ `2drop`
require sin_forth/lib/two-over.fs \ `2over`
require sin_forth/lib/two-swap.fs \ `2swap`

boot-here

exx, h push, \ preserve the HL' register, used by BASIC

67 literal \ "C"
68 literal \ "D"
65 literal \ "A"
66 literal \ "B"

2swap

00 literal
00 literal 2drop

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

h pop, exx, \ restore the HL' register, used by BASIC
ret,        \ exit to BASIC

6 data-stack-here

end-program

\ ==============================================================
\ Change log {{{1

\ 2020-12-24: Start. Test `drop`, `dup`, `swap`, `over`, `2over`,
\ `2swap`, `2drop`.
