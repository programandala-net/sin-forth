\ lib/less-number-sign.fs
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

require h-l-d.fs \ `hld`
require pad.fs   \ `pad`
require store.fs \ `!`

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
