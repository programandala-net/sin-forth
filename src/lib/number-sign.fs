\ lib/number-sign.fs
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

require base.fs          \ `base`
require fetch.fs         \ `@`
require hold.fs          \ `hold`
require rot.fs           \ `rot`
require to-digit.fs      \ `>digit`
require u-d-slash-mod.fs \ `ud/mod`

get-order get-current

target-definitions

: # ( ud1 -- ud2 )
  base @ ud/mod rot >digit hold ;

  \ doc{
  \
  \ # ( ud1 -- ud2 ) "number-sign"
  \
  \ Divide _ud1_ by the number in `base`, giving the quotient
  \ _ud2_ and the remainder _n_. (_n_ is the least significant
  \ digit of _ud1_.)  Convert _n_ to external form and add the
  \ resulting character to the beginning of the pictured numeric
  \ output string that was started by `<#`.
  \
  \ ``#`` is tipically used between `<#` and `#>`.
  \
  \ See also: `hold`, `ud/mod`, `>digit`.
  \
  \ }doc

set-current set-order
