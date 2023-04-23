\ lib/less-than.fs
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

require pop-de-hl.fs \ `pop-de-hl`

get-order get-current

target-definitions

: < ( n1 n2 -- f )

  pop-de-hl \ call pop_de_hl

: hl<de? ( -- f )

  assembler{

  \ a or,               \ or a      ; Fc=0
  \ d sbcp,             \ sbc hl,de ; n1-n2 in HL, SZVC valid
  \                     \ ; negative & not OV:  HL<DE
  \                     \ ; negative & OV:      HL +ve, DE -ve, result -ve, so HL>DE
  \                     \ ; positive & not OV:  HL>=DE
  \                     \ ; positive & OV:      HL -ve, DE +ve, result +ve, so HL<DE
  \                     \ ; thus OV reverses the sense of the sign bit
  \ po? aif             \ jp pe,less_than.reverse  ; if OV, jump
  \                     \ ; not overflow
  \   false_dea p? ?jp, \ jp p,false_    ; if +ve, result false
  \   true_dea jp,      \ jp true_       ; if -ve, result true
  \ athen               \ less_than.reverse:
  \                     \ ; overflow
  \ false_dea m? ?jp,   \ jp m,false_    ; if -ve, result false
  \ true_dea jp,        \ jp true_       ; if +ve, result true
  }

  \ Credit: Code adapted from Solo Forth, previously adapted from Z88
  \ CamelForth (Gary Lancaster, 2001).

  \ doc{
  \
  \ < ( n1 n2 -- f ) "less-than"
  \
  \ _f_ is true if and only if _n1_ is less than _n2_.
  \
  \ See also: `>`, `u<`, `0<`, `min`, `hl<de?`.
  \
  \ }doc

  \ doc{
  \
  \ hl<de? ( -- f ) "h-l-less-than-d-e-question"
  \
  \ ....
  \ Input:
  \   HL = n1
  \   DE = n2
  \ ....
  \
  \ _f_ is true if and only if _n1_ is less than _n2_.
  \
  \ See also: `<`, `>`, `u<`, `0<`, `min`.
  \
  \ }doc

set-current set-order
