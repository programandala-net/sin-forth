\ lib/h-l-d.fs

\ This file is part of Sin Forth.

\ This file adds `hld` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012261814.
\ See change log at the end of the file.

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

\ ==============================================================
\ Change log {{{1

\ 2020-12-26: Start.
