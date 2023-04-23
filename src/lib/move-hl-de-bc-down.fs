\ lib/move-hl-de-bc-down.fs
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

\ require x.fs \ `x`

get-order get-current

target-definitions

: move-hl-de-bc< ( -- )
  c a ld,  \ ld a,c
  b or,    \ or b
  z? ?ret, \ ret z
  b addp,  \ add hl,bc
  h decp,  \ dec hl
  exde,    \ ex de,hl
  b addp,  \ add hl,bc
  h decp,  \ dec hl
  exde,    \ ex de,hl
  lddr,    \ lddr
  ;        \ ret

  \ Credit: Code adapted from Solo Forth, previously from DZX-Forth,
  \ previously from DX-Forth.

  \ doc{
  \
  \ move-hl-de-bc< ( -- )

  \ ....
  \ Input:
  \   HL = source
  \   DE = destination
  \   BC = count
  \ ....

  \ If BC is greater than zero, copy BC consecutive characters
  \ from the data space starting at HL to that starting at DE,
  \ proceeding character-by-character from higher addresses to
  \ lower addresses.
  \
  \ See also: `move-hl-de-bc>`, `move-hl-de-bc`.
  \
  \ }doc

set-current set-order
