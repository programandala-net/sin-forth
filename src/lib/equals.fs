\ lib/equals.fs

\ This file is part of Sin Forth.

\ This file adds `=` to the target.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

require false.fs     \ `false`
require pop-de-hl.fs \ `pop-de-hl`
require true.fs      \ `true`

get-order get-current

target-definitions

: = ( x1 x2 -- f )
  pop-de-hl          \ call pop_de_hl
  a or,              \ or a ; Fc=0
  d sbcp,            \ sbc hl,de
  false_dea nz? ?jp, \ jp nz,false_dea
  true_dea jp,       \ jp true_dea

  \ doc{
  \
  \ = ( x1 x2 -- f ) "equals"
  \
  \ _f_ is true only and only if _x1_ is bit-for-bit the same as
  \ _x1_.
  \
  \ See also: `<>`, `>`, `<`.
  \
  \ }doc

set-current set-order
