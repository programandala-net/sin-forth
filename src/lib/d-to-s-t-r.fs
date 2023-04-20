\ lib/d-to-s-t-r.fs

\ This file is part of Sin Forth.

\ This file adds `d>str` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202000000000.
\ See change log at the end of the file.

\ ==============================================================

require d-abs.fs               \ `dabs`
require less-number-sign.fs    \ `<#`
require number-sign-greater.fs \ `#>`
require number-sign-s.fs       \ `#s`
require rot.fs                 \ `rot`
require sign.fs                \ `sign`
require tuck.fs                \ `tuck`

get-order get-current

target-definitions

: d>str ( d -- ca len )
  tuck dabs <# #s rot sign #> ;

\ code here ...

  \ doc{
  \
  \ d>str ( d>str -- ca len ) "d-to-s-t-r"
  \
  \ Convert _d_ to string _ca len_ in the pictured numeric output
  \ string buffer.
  \
  \ ``d>str`` is a factor of `d.r`.
  \
  \ WARNING: The pictured numeric output string buffer is a
  \ transient region (with maximum size `/hold` bytes below `pad`,
  \ and start pointed by `hld`). Therefore the string _ca len_
  \ must be used or preserved before the buffer is moved or
  \ overwritten.
  \
  \ See also: `<#`, `#s`, `sign` ,`#>`, `>stringer`, `s,`,
  \ `cmove`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-26: Start.
