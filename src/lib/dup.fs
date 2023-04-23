\ lib/dup.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230423T1138+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

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
