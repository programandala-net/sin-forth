\ lib/hold.fs
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

require c-store.fs    \ `c!`
require fetch.fs      \ `@`
require h-l-d.fs      \ `hld`
require plus-store.fs \ `+!`

get-order get-current

target-definitions

: hold ( c -- )
  -1 literal hld +!  hld @ c! ;

  \ doc{
  \
  \ hold ( c -- )
  \
  \ Insert character _c_ into a pictured numeric output string.
  \ Typically used between `<#` and `#>`.
  \
  \ See also: `holds`.
  \
  \ }doc

set-current set-order
