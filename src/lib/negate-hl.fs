\ lib/negate-hl.fs

\ This file is part of Sin Forth.

\ This file adds `negate-hl` to the target.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

get-order get-current

target-definitions

: negate-hl ( -- )

  assembler{
          \         ;  T  B
          \         ; -- --
  a xor,  \ xor a   ; 04 01
  l sub,  \ sub l   ; 04 01
  a l ld, \ ld l,a  ; 04 01
  a sbc,  \ sbc a,a ; 04 01
  h sub,  \ sub h   ; 04 01
  a h ld, \ ld h,a  ; 04 01
  ;       \ ret     ; 10 01
  }
          \         ; -- --
          \         ; 34 07 Total

  \ Credit:
  \
  \ http://wikiti.brandonw.net/index.php?title=Z80_Routines:Math:Signed_Math

  \ doc{
  \
  \ negate-hl ( -- )
  \
  \ ....
  \ Input:
  \   HL
  \ Ouput:
  \   HL = negated
  \   A = corrupted
  \ ....
  \
  \ Negate ``HL``, replacing it with its arithmetic inverse.
  \
  \ See also: `negate`.
  \
  \ }doc

set-current set-order
