\ lib/base.fs

\ This file is part of Sin Forth.

\ This file adds `base` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012261903.
\ See change log at the end of the file.

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

\ ==============================================================
\ Change log {{{1

\ 2020-12-26: Start.
