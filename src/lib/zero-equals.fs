\ lib/zero-equals.fs
\ by Marcos Cruz (programandala.net), 2023.
\ Last modified: 20230426T0803+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require false.fs  \ `false`
require pop-hl.fs \ `pop-hl`
require true.fs   \ `true`

: 0= ( x -- f )
  pop-hl             \ call pop_hl
  l a ld,            \ ld a,l
  h or,              \ or h
  false_dea nz? ?jp, \ jp nz,false_dea
  true_dea jp,       \ jp true_dea

  \ doc{
  \
  \ 0= ( x -- f ) "zero-equals"
  \
  \ _f_ is true if and only if _x_ is equal to zero.
  \
  \ // XXX TODO See also: `0<>`, `0<`, `0>`, `negate`, `invert`.
  \ See also: `0<`, `negate`.
  \
  \ }doc
