\ lib/equals.fs

\ This file is part of Sin Forth.

\ This file adds `=` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012122003.
\ See change log at the end of the file.

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

\ ==============================================================
\ Change log {{{1

\ 2020-12-12: Start.
\
\ 2020-12-26: Fix code comment.
