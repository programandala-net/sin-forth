\ lib/equals.fs
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
