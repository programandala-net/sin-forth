\ lib/d-abs.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230425T0812+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require dup.fs               \ `dup`
require question-d-negate.fs \ `?dnegate`

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
