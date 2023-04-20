\ lib/abs.fs

\ This file is part of Sin Forth.

\ This file adds `abs` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012260353.
\ See change log at the end of the file.

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

\ ==============================================================
\ Change log {{{1

\ 2020-12-26: Start.
