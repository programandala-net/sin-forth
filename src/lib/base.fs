\ lib/base.fs
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

require variable.fs \ `variable`

get-order get-current

target-definitions

variable base
10 literal base !

  \ doc{
  \
  \ base ( -- a )
  \
  \ A `variable`. _a_ is the address of a cell containing the current
  \ number-conversion radix. Its default value is #10.
  \
  \ See also: `>number`, `number?`, `abase`.
  \
  \ }doc

set-current set-order
