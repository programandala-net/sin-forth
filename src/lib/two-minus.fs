\ lib/two-minus.fs

\ This file is part of Sin Forth.

\ This file adds `2-` to the target system.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012120025.
\ See change log at the end of the file.

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

\ ==============================================================
\ Change log {{{1

\ 2020-12-12: Start.
