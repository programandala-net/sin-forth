\ lib/compare-de-hl-unsigned.fs
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

get-order get-current

target-definitions

: compare-de-hl-unsigned ( -- )
  assembler{
            \         ;  T  B
            \         ; -- --
  h a ld,   \ ld a,h  ; 04 01
  d cp,     \ cp d    ; 04 01
  nz? ?ret, \ ret nz  ; 11 01  05 01
  l a ld,   \ ld a,l  ; 04 01
  e cp,     \ cp e    ; 04 01
  ;         \ ret     ; 10 01
  }
            \         ; -- --  -- --
            \         ; 37 06  31 06 Total

  \ Credit: Code adapted from Solo Forth, previously from DZX-Forth,
  \ previously from DX-Forth.

  \ doc{
  \
  \ compare-de-hl-unsigned ( -- )

  \ ....
  \ Input:
  \   DE, HL
  \ Output (HL<DE):
  \   Fc=1
  \ Output (HL=DE):
  \   Fz=1
  \ ....

  \ See also: `compare-de-hl`.
  \
  \ }doc

set-current set-order
