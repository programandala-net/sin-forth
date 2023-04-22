\ lib/d-abs.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1824+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================

require dup.fs               \ `dup`
require question-d-negate.fs \ `?dnegate`

get-order get-current

target-definitions

: dabs ( d -- ud )
  dup ?dnegate ;

  \ doc{
  \
  \ dabs ( d -- ud ) "d-abs"
  \
  \ Leave the absolute value _ud_ of a double number _d_.
  \
  \ See also: `abs`, `?dnegate`.
  \
  \ }doc

set-current set-order
