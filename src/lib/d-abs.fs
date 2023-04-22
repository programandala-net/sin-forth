\ lib/d-abs.fs

\ This file is part of Sin Forth.

\ This file adds `dabs` to the target.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

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
