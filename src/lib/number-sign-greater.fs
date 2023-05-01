\ lib/number-sign-greater.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230501T1318+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require fetch.fs    \ `@`
require h-l-d.fs    \ `hld`
require hold-end.fs \ `hold-end`
require minus.fs    \ `-`
require over.fs     \ `over`
require two-drop.fs \ `2drop`

: #> ( xd -- ca len )
  2drop hld @ hold-end over - ;

  \ doc{
  \
  \ #> ( xd -- ca len ) "number-sign-greater"
  \
  \ End the pictured numeric output conversion that was started by
  \ `<#`: Drop _xd_ and make the pictured numeric output string
  \ available as the string _ca len_.
  \
  \ See also: `#`, `#s`, `hold`, `hld`, `sign`, `hold-buffer`.
  \
  \ }doc
