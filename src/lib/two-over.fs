\ lib/two-over.fs

\ This file is part of Sin Forth.

\ This file adds `2over` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012240137.
\ See change log at the end of the file.

\ ==============================================================

require push-de-hl.fs \ `push-de-hl`

get-order get-current

target-definitions

: 2over ( x1 x2 x3 x4 -- x1 x2 x3 x4 x1 x2 )
  4 ix l ftx, \ ld l,(ix+4)
  5 ix h ftx, \ ld h,(ix+5)
  6 ix e ftx, \ ld e,(ix+6)
  7 ix d ftx, \ ld d,(ix+7)
  push-de-hl  \ call push_de_hl
  ;           \ ret

  \ doc{
  \
  \ 2over ( x1 x2 x3 x4 -- x1 x2 x3 x4 x1 x2 ) "two-over"
  \
  \ Copy cell pair _x1 x2_ on top of the stack.
  \
  \ See also: `over`, `2swap`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-24: Start.
