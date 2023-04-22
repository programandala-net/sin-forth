\ lib/abs.fs

\ This file is part of Sin Forth.

\ This file adds `abs` to the target.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

require dup.fs             \ `dup`
require question-negate.fs \ `?negate`

get-order get-current

target-definitions

: abs ( n -- u )
  dup ?negate ;

  \ doc{
  \
  \ abs ( n -- u )
  \
  \ Leave the absolute value _u_ of a number _n_.
  \
  \ See also: `abs`, `?dnegate`.
  \
  \ }doc

set-current set-order
