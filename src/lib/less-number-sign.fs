\ lib/less-number-sign.fs

\ This file is part of Sin Forth.

\ This file adds `<#` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012261529.
\ See change log at the end of the file.

\ ==============================================================

require h-l-d.fs \ `hld`
require pad.fs   \ `pad`
require store.fs \ `!`

get-order get-current

target-definitions

: <# ( -- )
  pad hld ! ;

  \ doc{
  \
  \ <# ( -- ) "less-number-sign"
  \
  \ Initialize the pictured numeric output process:
  \ Set `hld` to its initial value, right below `pad`.
  \
  \ See also: `/hold`, `#>`, `#`, `#s`, `hold`, `holds`, `sign`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-26: Start.
