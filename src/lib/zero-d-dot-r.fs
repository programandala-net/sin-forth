\ lib/zero-d-dot-r.

\ This file is part of Sin Forth.

\ This file adds `0d.r` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012260413.
\ See change log at the end of the file.

\ ==============================================================

require d-dot-r.fs \ `d.r`

get-order get-current

target-definitions

: 0d.r ( d -- )
  0 literal d.r ;

  \ doc{
  \
  \ 0d.r ( d -- ) "zero-d-dot-r"
  \
  \ Display _d_ according to current base, with no leading or
  \ trailing spaces.  ``d0.r`` is a faster alternative to the
  \ idiom ``0 d.r``.
  \
  \ See also: `d.r`, `0.r`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-26: Start.
