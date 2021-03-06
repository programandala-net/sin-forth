\ lib/tuck.fs

\ This file is part of Sin Forth.

\ This file adds `tuck` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012251438.
\ See change log at the end of the file.

\ ==============================================================

require push-hl.fs \ `push-hl`

get-order get-current

target-definitions

: tuck ( x1 x2 -- x2 x1 x2 )
  0 ix l ftx, \ ld l,(ix+0)
  1 ix h ftx, \ ld h,(ix+1)
  2 ix e ftx, \ ld e,(ix+2)
  3 ix d ftx, \ ld d,(ix+3)
  e 0 ix stx, \ ld (ix+0),e
  d 1 ix stx, \ ld (ix+1),d
  l 2 ix stx, \ ld (ix+2),l
  h 3 ix stx, \ ld (ix+3),h
  push-hl     \ call push_hl
  ;           \ ret

  \ doc{
  \
  \ tuck ( x1 x2 -- x2 x1 x2 )
  \
  \ Copy the first (top) stack item below the second stack item.
  \
  \ See also: `dup`, `over`, `nip`, `nup`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-25: Start.
