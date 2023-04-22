\ lib/question-d-negate.fs

\ This file is part of Sin Forth.

\ This file adds `?dnegate` to the target.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

require pop-hl.fs   \ `pop-hl`
require d-negate.fs \ `dnegate`

get-order get-current

target-definitions

: ?dnegate ( d1 n -- d1|d2 )
  pop-hl               \ call pop_hl
: ?dnegate-hl
  h 7 bit,             \ bit 7,h
  dnegate_dea nz? ?jp, \ jp nz,d_negate_
  ;                    \ ret

  \ doc{
  \
  \ ?dnegate ( d1 n -- d1|d2 ) "question-d-negate"
  \
  \ If _n_ is negative, negate _d1_, giving its arithmetic inverse
  \ _d2_. Otherwise return _d1_.
  \
  \ ``?dnegate`` is written in Z80. Its equivalent definition in
  \ Forth is the following:

  \ ----
  \ : ?dnegate ( d1 n -- d1|d2 ) 0< if dnegate then ;
  \ ----

  \ NOTE: ``?dnegate`` is equivalent to fig-Forth's ``d+-``.
  \
  \ See also: `dnegate`, `?negate`, `?dnegate-hl`.
  \
  \ }doc

  \ doc{
  \
  \ ?dnegate-hl ( d1 -- d1|d2 ) "question-d-negate-h-l"
  \
  \ If ``HL`` is negative, negate _d1_, giving its arithmetic inverse
  \ _d2_. Otherwise return _d1_.
  \
  \ See also: `?dnegate`, `dnegate`, `?negate`.
  \
  \ }doc

set-current set-order
