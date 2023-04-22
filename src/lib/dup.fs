\ lib/dup.fs

\ This file is part of Sin Forth.

\ This file adds `dup` to the target.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

require push-hl.fs  \ `push-hl`

get-order get-current

target-definitions

: dup ( x -- x x )
  0 ix l ftx, \ ld l,(ix+0)
  1 ix h ftx, \ ld h,(ix+1)
  push-hl     \ call push_hl
  ;           \ ret

  \ doc{
  \
  \ dup ( x -- x x )
  \
  \ Duplicate _x_.
  \
  \ // XXX TODO
  \ See also: `?dup`, `2dup`, `tuck`, `over`, `0dup`, `-dup`,
  \ `nup`, `3dup`, `dup>r`.
  \
  \ See also: `over`.
  \
  \ }doc

set-current set-order
