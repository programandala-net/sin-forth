\ lib/less-number-sign.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1820+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

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
