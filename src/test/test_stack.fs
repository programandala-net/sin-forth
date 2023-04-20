#! /usr/bin/env gforth

\ test_stack.fs

\ This file is part of Sin Forth.

\ A Forth cross-compiler, written in Forth with Gforth,
\ that compiles Forth programs for the Sinclair ZX Spectrum.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230420T1135+0200.
\ See change log at the end of the file.

\ ==============================================================

require sin_forth/compiler.fs

40000 set-origin
s" test_stack" set-filename

begin-program

require sin_forth/lib/c-r.fs      \ `cr`
require sin_forth/lib/emit.fs     \ `emit`
require sin_forth/lib/literal.fs  \ `literal`
require sin_forth/lib/drop.fs     \ `drop`
require sin_forth/lib/dup.fs      \ `dup`
require sin_forth/lib/nip.fs      \ `nip`
require sin_forth/lib/over.fs     \ `over`
require sin_forth/lib/swap.fs     \ `swap`
require sin_forth/lib/tuck.fs     \ `tuck`
require sin_forth/lib/two-drop.fs \ `2drop`
require sin_forth/lib/two-nip.fs  \ `2nip`
require sin_forth/lib/two-over.fs \ `2over`
require sin_forth/lib/two-swap.fs \ `2swap`

boot-here

exx, h push, \ preserve the HL' register, used by BASIC

00 literal
67 literal \ "C"
00 literal
tuck drop
68 literal \ "D"
2nip

00 literal
65 literal \ "A"
nip

66 literal \ "B"

2swap

00 literal
00 literal 2drop

2over swap emit \ "A"
       dup emit \ "B"
      drop
      swap emit \ "C"
           emit \ "D"
             cr
      swap emit \ "A"
           emit \ "B"

67 literal \ "C"
68 literal \ "D"

      over emit \ "C"
           emit \ "D"
      drop

h pop, exx, \ restore the HL' register, used by BASIC
ret,        \ exit to BASIC

6 data-stack

end-program

\ ==============================================================
\ Change log {{{1

\ 2020-12-24: Start. Test `drop`, `dup`, `swap`, `over`, `2over`,
\ `2swap`, `2drop`, `nip`.
\
\ 2020-12-25: Test `2nip`, `tuck`.
\
\ 2020-12-26: Update with `cr`.
\
\ 2023-04-20: Update with `data-stack`.
