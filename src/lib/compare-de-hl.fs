\ lib/compare-de-hl.fs
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

require compare-de-hl-unsigned.fs \ `compare-de-hl-unsigned`

get-order get-current

target-definitions

: compare-de-hl ( -- )
  h a ld,                            \ ld a,h
  d xor,                             \ xor d
  compare-de-hl-unsigned_dea p? ?jp, \ jp p,compare-de-hl-unsigned
  h a ld,                            \ ld a,h
  a ro,                              \ or a
  p? ?ret,                           \ ret p
  scf,                               \ scf
  ;                                  \ ret

  \ Credit: Code adapted from Solo Forth, previously from DZX-Forth,
  \ previously from DX-Forth.

  \ doc{
  \
  \ compare-de-hl ( -- )

  \ ....
  \ Input:
  \   DE, HL
  \ Output (HL<DE):
  \   Fc=1
  \ ....

  \ See also: `compare-de-hl-unsigned`.
  \
  \ }doc

set-current set-order
