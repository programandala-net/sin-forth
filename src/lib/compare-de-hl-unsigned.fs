\ lib/compare-de-hl-unsigned.fs

\ This file is part of Sin Forth.

\ This file adds `compare-de-hl-unsigned` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012262341.
\ See change log at the end of the file.

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

\ ==============================================================
\ Change log {{{1

\ 2020-12-25: Start.
\
\ 2020-12-26: Update with `assembler{`.
