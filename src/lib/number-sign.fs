\ lib/number-sign.fs

\ This file is part of Sin Forth.

\ This file adds `#` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012261859.
\ See change log at the end of the file.

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

\ ==============================================================
\ Change log {{{1

\ 2020-12-26: Start.
