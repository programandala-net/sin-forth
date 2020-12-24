\ lib/swap.fs

\ This file is part of Sin Forth.

\ This file adds `swap` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012240140.
\ See change log at the end of the file.

\ ==============================================================

get-order get-current

target-definitions

: swap ( x1 x2 -- x2 x1 )
  0 ix l ftx, \ ld l,(ix+0)
  1 ix h ftx, \ ld h,(ix+1)
  2 ix e ftx, \ ld e,(ix+2)
  3 ix d ftx, \ ld d,(ix+3)
  e 0 ix stx, \ ld (ix+0),e
  d 1 ix stx, \ ld (ix+1),d
  l 2 ix stx, \ ld (ix+2),l
  h 3 ix stx, \ ld (ix+3),h
  ;           \ ret

  \ doc{
  \
  \ swap ( x1 x2 -- x2 x1 )
  \
  \ Exchange the top two stack items.
  \
  \ See also: `2swap`, `over`, `tuck`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-24: Start.
