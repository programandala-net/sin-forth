\ lib/d-abs.fs

\ This file is part of Sin Forth.

\ This file adds `dabs` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012260348.
\ See change log at the end of the file.

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

\ ==============================================================
\ Change log {{{1

\ 2020-12-26: Start.
