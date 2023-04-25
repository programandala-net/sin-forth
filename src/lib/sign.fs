\ lib/sign.fs
\ by Marcos Cruz (programandala.net), 2023.
\ Last modified: 20230425T0829+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require hold.fs      \ `hold`
require if.fs        \ `if`
require then.fs      \ `then`
require zero-less.fs \ `0<`

: sign ( n  --  )
  0< if '-' literal hold then ;

  \ doc{

  \ sign ( n  --  )

  \ If _n_ is negative, add a minus sign to the beginning of the
  \ pictured numeric output string.
  \
  \ See also: `<#`, `#>`, `hold`.
  \
  \ }doc
