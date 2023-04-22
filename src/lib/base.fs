\ lib/base.fs

\ This file is part of Sin Forth.

\ This file adds `base` to the target.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

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
