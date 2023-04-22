\ lib/less-number-sign.fs

\ This file is part of Sin Forth.

\ This file adds `<#` to the target.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

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
