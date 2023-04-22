\ lib/two-minus.fs

\ This file is part of Sin Forth.

\ This file adds `2-` to the target.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

get-order get-current

target-definitions

: 2- ( n1 -- n2 )

  \ XXX slow variant:
  \ pop-hl h decp, h decp, push-hl ;

  \ XXX fast variant:
  0 ix l ftx, \ ld l,(ix+0)
  1 ix h ftx, \ ld l,(ix+1)
  h decp,     \ dec hl
  h decp,     \ dec hl
  l 0 ix stx, \ ld (ix+0),l
  h 1 ix stx, \ ld (ix+0),h
  ;           \ ret

set-current set-order
