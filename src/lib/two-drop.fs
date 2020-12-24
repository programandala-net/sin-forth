\ lib/two-drop.fs

\ This file is part of Sin Forth.

\ This file adds `2drop` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012240225.
\ See change log at the end of the file.

\ ==============================================================

get-order get-current

target-definitions

: 2drop ( x1 x2 -- )
  ix incp, \ inc ix
  ix incp, \ inc ix
  ix incp, \ inc ix
  ix incp, \ inc ix
  ;        \ ret

  \ doc{
  \
  \ 2drop ( x1 x2 -- ) "two-drop"
  \
  \ Remove cell pair _x1 x2_ from the stack.
  \
  \ See also: `drop`, `nip`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-24: Start.
