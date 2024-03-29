\ lib/move-hl-de-bc.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230425T0812+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require compare-de-hl-unsigned.fs \ `compare-de-hl-unsigned`
require move-hl-de-bc-down.fs     \ `move-hl-de-bc<`
require move-hl-de-bc-up.fs       \ `move-hl-de-bc>`

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
