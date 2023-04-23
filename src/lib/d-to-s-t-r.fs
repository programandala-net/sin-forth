\ lib/d-to-s-t-r.fs
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
