\ lib/over.fs

\ This file is part of Sin Forth.

\ This file adds `over` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012240130.
\ See change log at the end of the file.

\ ==============================================================

require push-hl.fs \ `push-hl`

get-order get-current

target-definitions

: over ( x1 x2 -- x1 x2 x1 )
  2 ix l ftx, \ ld l,(ix+2)
  3 ix h ftx, \ ld h,(ix+3)
  push-hl     \ call push_hl
  ;           \ ret

  \ doc{
  \
  \ over ( x1 x2 -- x1 x2 x1 )
  \
  \ Place a copy of _x1_ on top of the stack.
  \
  \ See also: `dup`, `swap`, `2over`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-24: Start.
