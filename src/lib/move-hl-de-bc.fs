\ lib/move-hl-de-bc.fs

\ This file is part of Sin Forth.

\ This file adds `move-hl-de-bc` to the target.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

require compare-de-hl-unsigned.fs \ `compare-de-hl-unsigned`
require move-hl-de-bc-down.fs     \ `move-hl-de-bc<`
require move-hl-de-bc-up.fs       \ `move-hl-de-bc>`

get-order get-current

target-definitions

: move-hl-de-bc ( -- )
  compare-de-hl-unsigned     \ call compare-de-hl-unsigned
  move-hl-de-bc<_dea c? ?jp, \ jp c,move-hl-de-bc<
  move-hl-de-bc> ;           \ jp move-hl-de-bc>

  \ doc{

  \ move-hl-de-bc ( -- )
  \
  \ ....
  \ Input:
  \   HL = source
  \   DE = destination
  \   BC = count
  \ ....

  \ If BC is greater than zero, copy the contents of BC
  \ consecutive bytes at HL to the BC consecutive bytes at DE.
  \ After the move completes, the BC consecutive bytes at DE
  \ contain exactly what the BC consecutive bytes at HL
  \ contained before the move.
  \
  \ See also: `move-hl-de-bc>`, `move-hl-de-bc<`.
  \
  \ }doc

set-current set-order
