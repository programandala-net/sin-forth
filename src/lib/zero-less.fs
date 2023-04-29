\ lib/zero-less.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230427T1323+0200.

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

: 0< ( n -- f )
  pop-hl           \ call pop_hl
  h rl,            \ rl h
  true_dea c? ?jp, \ jp c,true_dea
  false_dea jp,    \ jp false_dea

  \ Credit: Code adapted from Solo Forth. The idea to use `rl h` was
  \ copied from Ace Forth to Solo Forth.

  \ doc{
  \
  \ 0< ( n -- f ) "0-less"
  \
  \ _f_ is true if and only if _n_ is less than zero.
  \
  \ See also: `0>`, `0<=`, `0=`, `0<>`.
  \
  \ }doc
