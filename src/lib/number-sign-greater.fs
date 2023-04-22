\ lib/number-sign-greater.fs

\ This file is part of Sin Forth.

\ This file adds `#>` to the target.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

require fetch.fs    \ `@`
require h-l-d.fs    \ `hld`
require minus.fs    \ `-`
require over.fs     \ `over`
require pad.fs      \ `pad`
require two-drop.fs \ `2drop`

get-order get-current

compiler-definitions

: #> ( xd -- ca len )
  2drop hld @ pad over - ;

  \ doc{
  \
  \ #> ( xd -- ca len ) "number-sign-greater"
  \
  \ End the pictured numeric output conversion that was started by
  \ `<#`: Drop _xd_ and make the pictured numeric output string
  \ available as the string _ca len_.
  \
  \ See also: `#`, `#s`, `hold`, `hld`, `sign`, `pad`.
  \
  \ }doc

set-current set-order
