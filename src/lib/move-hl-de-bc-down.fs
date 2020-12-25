\ lib/move-hl-de-bc-down.fs

\ This file is part of Sin Forth.

\ This file adds `move-hl-de-bc<` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012252108.
\ See change log at the end of the file.

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

\ ==============================================================
\ Change log {{{1

\ 2020-12-25: Start.
