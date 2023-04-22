\ lib/h-l-d.fs

\ This file is part of Sin Forth.

\ This file adds `hld` to the target.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

require variable.fs \ `variable`

get-order get-current

target-definitions

variable hld

  \ doc{
  \
  \ hld ( -- a ) "h-l-d"
  \
  \ A `variable`. _a_ is the address of a cell containing the
  \ address of the latest character of text during numeric output
  \ conversion.
  \
  \ See also: `hold`, `<#`, `#>`.
  \
  \ }doc

set-current set-order
