\ lib/zero-less.fs

\ This file is part of Sin Forth.

\ This file adds `0<` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012260200.
\ See change log at the end of the file.

\ ==============================================================

require false.fs  \ `false`
require pop-hl.fs \ `pop-hl`
require true.fs   \ `true`

get-order get-current

target-definitions

: 0< ( n -- f )
  pop-hl           \ call pop_hl
  h rl,            \ rl h
  true_dea c? ?jp, \ jp c,false_dea
  false_dea jp,    \ jp true_dea

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

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-26: Start.
