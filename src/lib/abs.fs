\ lib/abs.fs
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
